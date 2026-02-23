import { Display } from "../components/Display";
import { Button } from "../components/Button";
import { HistoryPanel } from "../components/HistoryPanel";
import { calculate } from "../api/calculatorAPI";
import type { OperationType } from "../types/OperationType";
import { appendNumber,appendDecimal, setOperator,setResult, clearEntry,clearAll, addHistory,memoryAdd,memorySubtract,memoryRecall,} from "../store/calculatorSlice.ts"
import { useAppDispatch, useAppSelector } from "../store/hooks";

export const CalculatorPage = () => {
  const dispatch = useAppDispatch();

  const display = useAppSelector((state) => state.calculator.display);
  const operator = useAppSelector((state) => state.calculator.operator);
  const firstOperand = useAppSelector((state) => state.calculator.firstOperand);
  const history = useAppSelector((state) => state.calculator.history);
  const waitingForSecond = useAppSelector((state) => state.calculator.waitingForSecond);

  const handleNumber = (num: string) => dispatch(appendNumber(num));
  const handleDot = () => dispatch(appendDecimal());
  const handleOperator = (op: OperationType) => dispatch(setOperator(op));
  const handleClear = () => dispatch(clearAll());
  const handleClearEntry = () => dispatch(clearEntry());
  const handleMemoryPlus = () => dispatch(memoryAdd());
  const handleMemoryMinus = () => dispatch(memorySubtract());
  const handleMemoryRecall = () => dispatch(memoryRecall());

  const handleEquals = async () => {
    if (!operator || firstOperand === null) return;

    const rightOperand = parseFloat(display);

    try {
      const result = await calculate({
        left: firstOperand,
        right: rightOperand,
        operation: operator,
      });

      if (result.error && result.error !== "None") {
        alert(result.error);
        return;
      }

      dispatch(setResult(result.result));
      dispatch(
        addHistory(
          `${firstOperand} ${getOpSymbol(operator)} ${rightOperand} = ${result.result}`
        )
      );
    } catch(err) {
      alert("Server Communication Error: Please retry.");
      console.error("Calculation API failed:", err);
    }
  };

  const getOpSymbol = (op: OperationType) => {
    switch (op) {
      case "Addition": return "+";
      case "Subtraction": return "-";
      case "Multiplication": return "×";
      case "Division": return "÷";
    }
  };

  return (
    <div className="calculator">
      <Display
        value={
          operator && firstOperand !== null
            ? waitingForSecond
              ? `${firstOperand} ${getOpSymbol(operator)}`
              : `${firstOperand} ${getOpSymbol(operator)} ${display}`
            : display
        }
      />

      <div className="buttons">
        {["7", "8", "9", "4", "5", "6", "1", "2", "3", "0"].map((n) => (
          <Button key={n} label={n} onClick={() => handleNumber(n)} />
        ))}

        <Button label="." onClick={handleDot} />
        <Button label="C" onClick={handleClear} />
        <Button label="CE" onClick={handleClearEntry} />

        <Button label="M+" onClick={handleMemoryPlus} />
        <Button label="M-" onClick={handleMemoryMinus} />
        <Button label="MR" onClick={handleMemoryRecall} />

        <Button label="+" onClick={() => handleOperator("Addition")} />
        <Button label="-" onClick={() => handleOperator("Subtraction")} />
        <Button label="×" onClick={() => handleOperator("Multiplication")} />
        <Button label="÷" onClick={() => handleOperator("Division")} />

        <Button label="=" onClick={handleEquals} />
      </div>

      <HistoryPanel history={history} />
    </div>
  );
};