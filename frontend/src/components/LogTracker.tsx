function Logtracker({ logMsg }: { logMsg: string[] }) {
  return (
    <div className="log-tracker">
      {logMsg?.map((msg, idx) => (
        <p key={idx}>{msg}</p>
      ))}
    </div>
  );
}

export default Logtracker;