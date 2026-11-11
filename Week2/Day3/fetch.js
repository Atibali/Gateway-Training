async function getUser(id) {
  try {
    const response = await fetch(`https://jsonplaceholder.typicode.com/users/${id}`);

    // fetch does NOT reject on 4xx/5xx — check response.ok
    if (!response.ok) {
      throw new Error(`HTTP ${response.status}: ${response.statusText}`);
    }

    const user = await response.json();
    console.log("User:", user.name);
    return user;
  } catch (err) {
    // Handles both network errors AND our thrown HTTP errors
    console.error("Failed to fetch user:", err.message);
    return null;
  }
}

getUser(1);
// User: Leanne Graham

getUser(9999);
// Failed to fetch user: HTTP 404: Not Found

// POST example
async function createPost(data) {
  try {
    const response = await fetch("https://jsonplaceholder.typicode.com/posts", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(data),
    });
    if (!response.ok) throw new Error(`HTTP ${response.status}`);
    return await response.json();
  } catch (err) {
    console.error("Create failed:", err.message);
  }
}

createPost({ title: "Hello", body: "World", userId: 1 })
  .then(post => console.log("Created:", post));