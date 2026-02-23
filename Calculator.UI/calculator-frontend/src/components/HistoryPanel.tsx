interface HistoryPanelProps {
  history: string[];
}

export const HistoryPanel = ({ history }: HistoryPanelProps) => (
  <div className="history-panel">
    {history.map((h, i) => (
      <div key={i}>{h}</div>
    ))}
  </div>
);