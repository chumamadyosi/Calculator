// CalculatorService.ts
export class CalculatorService {
  private memory: number = 0;
  private history: string[] = [];

  addToMemory(val: number) {
    this.memory += val;
  }

  subtractFromMemory(val: number) {
    this.memory -= val;
  }

  recallMemory(): number {
    return this.memory;
  }

  clearMemory() {
    this.memory = 0;
  }

  addHistory(entry: string) {
    this.history.push(entry);
  }

  getHistory(): string[] {
    return [...this.history];
  }

  formatDisplay(val: number) {
    // Limit to 8 digits before decimal, max 2 decimal places
    return parseFloat(val.toFixed(8)).toString();
  }

  clearHistory() {
    this.history = [];
  }
}