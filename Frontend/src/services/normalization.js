export const postTable = payload => {
  return fetch("http://localhost:58183/api/schema/post", {
    method: "POST",
    mode: "cors",
    headers: {
      "Content-Type": "application/json"
    },
    redirect: "follow",
    referrer: "no-referrer",
    body: JSON.stringify(payload)
  }).then(response => response.json());
};

export const fetchStoredTables = () => {};
