const ticketService = require("../services/ticket.service");
const asyncHandler = require("../utils/asyncHandler");

const createTicket = asyncHandler(async (req, res) => {
    const ticket = await ticketService.createTicket(req.body);

    res.status(201).json({
        success: true,
        message: "Ticket created successfully",
        data: ticket
    });
});

const getAllTickets = asyncHandler(async (req, res) => {
    const tickets = await ticketService.getAllTickets();

    res.status(200).json({
        success: true,
        data: tickets
    });
});

const getTicketById = asyncHandler(async (req, res) => {
    const ticket = await ticketService.getTicketById(req.params.id);

    res.status(200).json({
        success: true,
        data: ticket
    });
});

module.exports = {
    createTicket,
    getAllTickets,
    getTicketById
};