const { test, expect } = require("@playwright/test");

test("ticket API creates a ticket and returns it in list and detail requests", async ({ request }) => {
    const title = `Playwright ticket ${Date.now()}`;
    const description = "Created by the Playwright API test";

    const createResponse = await request.post("/api/tickets", {
        data: { title, description }
    });

    expect(createResponse.status()).toBe(201);
    const createBody = await createResponse.json();
    expect(createBody).toMatchObject({
        success: true,
        message: "Ticket created successfully",
        data: {
            title,
            description,
            status: "OPEN",
            priority: "MEDIUM"
        }
    });
    expect(createBody.data._id).toBeTruthy();
    expect(typeof createBody.data.ticketNumber).toBe("number");

    const listResponse = await request.get("/api/tickets");
    expect(listResponse.status()).toBe(200);
    const listBody = await listResponse.json();
    expect(listBody.success).toBe(true);
    expect(listBody.data).toContainEqual(expect.objectContaining({
        _id: createBody.data._id,
        title
    }));

    const detailResponse = await request.get(`/api/tickets/${createBody.data._id}`);
    expect(detailResponse.status()).toBe(200);
    expect(await detailResponse.json()).toMatchObject({
        success: true,
        data: {
            _id: createBody.data._id,
            title,
            description
        }
    });
});
