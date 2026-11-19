const Ticket = require("../models/Ticket");
const Counter = require("../models/Counter");

const createTicket = async (ticketData) => {
    const counter = await Counter.findByIdAndUpdate(
        "ticket",
        {
            $inc: {
                seq: 1
            }
        },
        {
            new: true,
            upsert: true,
            setDefaultsOnInsert: true
        }
    );

    const ticket = await Ticket.create({
        ...ticketData,
        ticketNumber: counter.seq
    });

    return ticket;
};

const getAllTickets = async () => {
    return Ticket.find().lean();
};

const getTicketById = async (id) => {
    const ticket = await Ticket.findById(id).lean();

    if (!ticket) {
        const error = new Error("Ticket not found");
        error.statusCode = 404;
        throw error;
    }

    return ticket;
};

module.exports = {
    createTicket,
    getAllTickets,
    getTicketById
};