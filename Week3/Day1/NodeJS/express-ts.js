// src/index.ts
import express, { Request, Response, NextFunction } from 'express';
import { config } from './config.js';

const app = express();
app.use(express.json());

app.get('/api/health', (_req: Request, res: Response) => {
  res.json({ ok: true, port: config.port });
});

// Typed error handler
app.use((err: unknown, _req: Request, res: Response, _next: NextFunction) => {
  console.error(err);
  res.status(500).json({ error: 'Internal server error' });
});

app.listen(config.port, () => {
  console.log(`Server on http://localhost:${config.port}`);
});