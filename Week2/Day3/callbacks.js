// Nested callbacks become hard to read ("callback hell")
function getUser(id, callback) {
  setTimeout(() => {
    callback(null, { id, name: "Alice" });
  }, 100);
}

function getOrders(userId, callback) {
  setTimeout(() => {
    callback(null, [{ id: 101, userId }, { id: 102, userId }]);
  }, 100);
}

function getOrderDetails(orderId, callback) {
  setTimeout(() => {
    callback(null, { id: orderId, total: 49.99, status: "Paid" });
  }, 100);
}

getUser(1, (userError, user) => {
  if (userError) return console.error(userError);

  console.log("User:", user.name);

  getOrders(user.id, (ordersError, orders) => {
    if (ordersError) return console.error(ordersError);

    console.log("Orders:", orders.length);

    getOrderDetails(orders[0].id, (detailsError, details) => {
      if (detailsError) return console.error(detailsError);
      console.log("Order details:", details);
    });
  });
});