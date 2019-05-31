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

export const updateTable = payload => {
  return fetch("http://localhost:58183/api/schema/update", {
    method: "PUT",
    mode: "cors",
    headers: {
      "Content-Type": "application/json"
    },
    redirect: "follow",
    referrer: "no-referrer",
    body: JSON.stringify(payload)
  }).then(response => response.json());
};

export const fetchStoredTables = () => {
  return fetch("http://localhost:58183/api/schema/get").then(response =>
    response.json()
  );
};

export const fetchTableById = id => {
  return fetch(`http://localhost:58183/api/schema/get/${id}`).then(response =>
    response.json()
  );
};

export const deleteTable = id => {
  return fetch(`http://localhost:58183/api/schema/delete/${id}`, {
    method: "DELETE",
    headers: { "Content-Type": "application/json" }
  });
};

export const runAlgorithm = id => {
  return fetch(`http://localhost:58183/api/normalization/generate/${id}`).then(
    response => response.json()
  );
};
