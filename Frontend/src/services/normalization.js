const CONNECTION_PORT_API = "http://localhost:58183/api/";

export const postTable = payload => {
  return fetch(`${CONNECTION_PORT_API}schema/post`, {
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
  return fetch(`${CONNECTION_PORT_API}schema/update`, {
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
  return fetch(`${CONNECTION_PORT_API}schema/get`).then(response =>
    response.json()
  );
};

export const fetchTableById = id => {
  return fetch(`${CONNECTION_PORT_API}schema/get/${id}`).then(response =>
    response.json()
  );
};

export const deleteTable = id => {
  return fetch(`${CONNECTION_PORT_API}schema/delete/${id}`, {
    method: "DELETE",
    headers: { "Content-Type": "application/json" }
  });
};

export const runAlgorithm = id => {
  return fetch(`${CONNECTION_PORT_API}normalization/generate/${id}`).then(
    response => response.json()
  );
};
