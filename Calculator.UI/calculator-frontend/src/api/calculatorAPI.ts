import type { CalculateRequest } from "../Interface/CalculateRequest";
import type { CalculateResponse } from "../Interface/CalculateResponse";

export async function calculate(request: CalculateRequest): Promise<CalculateResponse> {
  const res = await fetch('https://localhost:7268/api/calculator/calculate', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(request),
  });

  if (!res.ok) throw new Error(`API error: ${res.statusText}`);
  return res.json();
}