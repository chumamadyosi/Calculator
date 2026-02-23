import { createSlice } from "@reduxjs/toolkit";
import type { OperationType } from "../types/OperationType";
import type { PayloadAction } from "@reduxjs/toolkit";


interface CalculatorState {
  display: string;
  firstOperand: number | null;
  operator: OperationType | null;
  waitingForSecond: boolean;
  memory: number;
  history: string[];
}

const initialState: CalculatorState = {
  display: "0",
  firstOperand: null,
  operator: null,
  waitingForSecond: false,
  memory: 0,
  history: [],
};

const calculatorSlice = createSlice({
  name: "calculator",
  initialState,
  reducers: {
    appendNumber(state, action: PayloadAction<string>) {
      const num = action.payload;

      if (state.waitingForSecond) {
        state.display = num;
        state.waitingForSecond = false;
      } else {
       if (state.display.length < 12) {
        state.display = state.display === "0" ? num : state.display + num;
       }
    }
    },

    appendDecimal(state) {
      if (state.waitingForSecond) {
        state.display = "0.";
        state.waitingForSecond = false;
        return;
      }

      if (!state.display.includes(".")) {
        state.display += ".";
      }
    },

    setOperator(state, action: PayloadAction<OperationType>) {
      state.firstOperand = parseFloat(state.display);
      state.operator = action.payload;
      state.waitingForSecond = true;
    },

    setResult(state, action: PayloadAction<number>) {
      state.display = action.payload.toString();
      state.firstOperand = null;
      state.operator = null;
      state.waitingForSecond = false;
    },

    clearEntry(state) {
      state.display = "0";
    },

    clearAll(state) {
      state.display = "0";
      state.firstOperand = null;
      state.operator = null;
      state.waitingForSecond = false;
      state.memory = 0;
      state.history = [];
    },

    addHistory(state, action: PayloadAction<string>) {
      state.history.push(action.payload);
    },

    memoryAdd(state) {
      state.memory += parseFloat(state.display);
      state.waitingForSecond = true;
    },

    memorySubtract(state) {
      state.memory -= parseFloat(state.display);
      state.waitingForSecond = true;
    },

    memoryRecall(state) {
      state.display = state.memory.toString();
      state.waitingForSecond = false;
    },
  },
});

export const {
  appendNumber,
  appendDecimal,
  setOperator,
  setResult,
  clearEntry,
  clearAll,
  addHistory,
  memoryAdd,
  memorySubtract,
  memoryRecall,
} = calculatorSlice.actions;

export default calculatorSlice.reducer;