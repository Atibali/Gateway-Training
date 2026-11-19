const express = require("express");
const cors = require("cors");

const app = express();

const ticketRoutes = require("../routes/ticket.routes");
const errorHandler = require("../middleware/error.middleware");

app.use(cors({
    origin: "http://localhost:5173"
}));

app.use(express.json());

app.use(express.urlencoded({
    extended: true
}));

app.get("/", (req, res) => {
    res.json({
        success: true,
        message: "Ticket API is running"
    });
});

app.use("/api/tickets", ticketRoutes);

app.use(errorHandler);

module.exports = app;