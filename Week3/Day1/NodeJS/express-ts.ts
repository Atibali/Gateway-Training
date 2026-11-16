import express, { type NextFunction, type Request, type Response } from 'express';

const app = express();
const port = Number(process.env.PORT ?? 3000);

app.use(express.json());

app.get('/api/health', (_req: Request, res: Response) => {
  res.json({ ok: true, port });
});

// Typed error handler
app.use((err: unknown, _req: Request, res: Response, _next: NextFunction) => {
  console.error(err);
  res.status(500).json({ error: 'Internal server error' });
});

app.listen(port, () => {
  console.log(`Server on http://localhost:${port}`);
});