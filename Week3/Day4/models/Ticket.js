const mongoose = require("mongoose");

const ticketSchema = new mongoose.Schema({
    ticketNumber: {
        type: Number,
        unique: true,
        required: true
    },

    title: {
        type: String,
        required: true,
        trim: true,
        minlength: 5,
        maxlength: 100
    },

    description: {
        type: String,
        required: true,
        trim: true
    },

    status: {
        type: String,
        enum: ["OPEN", "IN_PROGRESS", "CLOSED"],
        default: "OPEN"
    },

    priority: {
        type: String,
        enum: ["LOW", "MEDIUM", "HIGH"],
        default: "MEDIUM"
    }
}, {
    timestamps: true
});

module.exports = mongoose.model("Ticket", ticketSchema);