import { useState } from "react";
import { Display } from "../components/Display";
import { Button } from "../components/Button";
import { HistoryPanel } from "../components/HistoryPanel";
import { calculate } from "../api/calculatorAPI";
import type { OperationType } from "../types/OperationType";

export const CalculatorPage = () => {
  const [display, setDisplay] = useState("0");
  const [firstOperand, setFirstOperand] = useState<number | null>(null);
  const [operator, setOperator] = useState<OperationType | null>(null);
  const [waitingForSecond, setWaitingForSecond] = useState(false);
  const [memory, setMemory] = useState<number>(0);
  const [history, setHistory] = useState<string[]>([]);

  // Append number
  const appendNumber = (num: string) => {
    if (display === "0" || waitingForSecond) {
      setDisplay(waitingForSecond && operator ? `${firstOperand} ${getOpSymbol(operator)} ${num}` : num);
      setWaitingForSecond(false);
    } else {
      setDisplay(display + num);
    }
  };

  // Append decimal
  const appendDecimal = () => {
    const parts = display.split(/[\+\-\×\÷]/);
    const lastNumber = parts[parts.length - 1];
    if (!lastNumber.includes(".")) setDisplay(display + ".");
  };

  // Clear Entry
  const clearEntry = () => {
    if (!operator) {
      setDisplay("0");
    } else {
      const parts = display.split(/[\+\-\×\÷]/);
      setDisplay(`${parts[0]} ${getOpSymbol(operator)}`);
      setWaitingForSecond(true);
    }
  };

  // Clear All
  const clearAll = () => {
    setDisplay("0");
    setFirstOperand(null);
    setOperator(null);
    setWaitingForSecond(false);
    setHistory([]);
    setMemory(0);
  };

  // Operator pressed
  const handleOperator = (op: OperationType) => {
    const parts = display.split(/[\+\-\×\÷]/);
    const left = parseFloat(parts[0]);

    if (firstOperand !== null && operator && !waitingForSecond) {
      handleEquals();
      setFirstOperand(parseFloat(display));
    } else {
      setFirstOperand(left);
    }

    setOperator(op);
    setWaitingForSecond(true);
    setDisplay(`${firstOperand ?? left} ${getOpSymbol(op)}`);
  };

  // Equals pressed
  const handleEquals = async () => {
    if (!operator || firstOperand === null) return;

    const parts = display.split(/[\+\-\×\÷]/);
    const right = parseFloat(parts[parts.length - 1] || "0");

    try {
      const result = await calculate({ left: firstOperand, right, operation: operator });

      if (result.error && result.error !== "None") {
        alert(result.error);
        return;
      }

      const formatted = parseFloat(result.result.toFixed(8)).toString();
      setDisplay(formatted);

      // Add to history
      const entry = `${firstOperand} ${getOpSymbol(operator)} ${right} = ${formatted}`;
      setHistory((prev) => [...prev, entry]);
    } catch {
      alert("API call failed");
    }

    setFirstOperand(null);
    setOperator(null);
    setWaitingForSecond(false);
  };

  // Memory buttons
  const handleMemory = (type: "M+" | "M-" | "MR") => {
    const parts = display.split(/[\+\-\×\÷]/);
    const val = parseFloat(parts[parts.length - 1]); // last number on display

    switch (type) {
      case "M+":
        setMemory((prev) => prev + val);
        break;
      case "M-":
        setMemory((prev) => prev - val);
        break;
      case "MR":
        setDisplay(memory.toString());
        break;
    }
  };

  // Map operator string
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
      <Display value={display} />

      <div className="buttons">
        {["7","8","9","4","5","6","1","2","3","0"].map(n =>
          <Button key={n} label={n} onClick={() => appendNumber(n)} />
        )}
        <Button label="." onClick={appendDecimal} />
        <Button label="C" onClick={clearAll} />
        <Button label="CE" onClick={clearEntry} />

        <Button label="M+" onClick={() => handleMemory("M+")} />
        <Button label="M-" onClick={() => handleMemory("M-")} />
        <Button label="MR" onClick={() => handleMemory("MR")} />

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