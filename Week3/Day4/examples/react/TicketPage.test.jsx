import { afterEach, beforeEach, describe, expect, it, vi } from 'vitest';
import { cleanup, render, screen, waitFor } from '@testing-library/react';
import userEvent from '@testing-library/user-event';
import TicketPage from './TicketPage';

describe('TicketPage', () => {
  beforeEach(() => {
    vi.stubGlobal('fetch', vi.fn());
  });

  afterEach(() => {
    cleanup();
    vi.unstubAllGlobals();
  });

  it('loads and displays tickets from GET /api/tickets', async () => {
    fetch.mockResolvedValue({
      ok: true,
      json: async () => ({
        success: true,
        data: [{
          _id: 'ticket-1',
          ticketNumber: 1,
          title: 'Existing ticket',
          description: 'A ticket returned by the API',
          status: 'OPEN',
          priority: 'MEDIUM'
        }]
      })
    });

    render(<TicketPage />);

    expect(await screen.findByText('Existing ticket')).toBeTruthy();
    expect(fetch).toHaveBeenCalledWith('/api/tickets');
  });

  it('submits the ticket form to POST /api/tickets', async () => {
    const user = userEvent.setup();
    fetch.mockImplementation(async (_url, options = {}) => {
      if (options.method === 'POST') {
        return {
          ok: true,
          json: async () => ({
            success: true,
            data: {
              _id: 'ticket-2',
              ticketNumber: 2,
              title: 'New ticket',
              description: 'Created from the form',
              status: 'OPEN',
              priority: 'MEDIUM'
            }
          })
        };
      }

      return { ok: true, json: async () => ({ success: true, data: [] }) };
    });

    render(<TicketPage />);

    await user.type(await screen.findByLabelText(/title/i), 'New ticket');
    await user.type(screen.getByLabelText(/description/i), 'Created from the form');
    await user.click(screen.getByRole('button', { name: /create ticket/i }));

    await waitFor(() => {
      expect(fetch).toHaveBeenCalledWith('/api/tickets', expect.objectContaining({
        method: 'POST',
        headers: expect.objectContaining({ 'Content-Type': 'application/json' }),
        body: JSON.stringify({
          title: 'New ticket',
          description: 'Created from the form'
        })
      }));
    });
  });
});
