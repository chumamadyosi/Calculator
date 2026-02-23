interface DisplayProps {
  value: string;
}

export const Display = ({ value }: DisplayProps) => (
  <div className="display">{value}</div>
);