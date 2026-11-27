import { describe, expect, it } from "vitest";
import request from "supertest";
import { createApp } from "../app";

describe("API health check", () => {
  it("returns an ok status", async () => {
    const response = await request(createApp()).get("/api/health");

    expect(response.status).toBe(200);
    expect(response.body).toEqual({ status: "ok" });
  });

  it("returns a JSON 404 for an unknown API route", async () => {
    const response = await request(createApp()).get("/api/missing");

    expect(response.status).toBe(404);
    expect(response.body).toEqual({ message: "API route not found" });
  });
});
