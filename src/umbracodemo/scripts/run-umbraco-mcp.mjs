import "dotenv/config";
import { spawn } from "node:child_process";

const child = spawn(
  "npx",
  ["-y", "@umbraco-cms/mcp-dev@latest"],
  {
    stdio: "inherit",
    shell: process.platform === "win32",
    env: process.env
  }
);

child.on("exit", (code, signal) => {
  if (signal) {
    process.kill(process.pid, signal);
    return;
  }

  process.exit(code ?? 0);
});
