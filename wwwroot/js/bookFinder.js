document.getElementById('bookForm').addEventListener('submit', function (e) {
    e.preventDefault();

    const selectedTitle = document.getElementById('bookTitle').value;

    fetch('/Home/FindBook', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ title: selectedTitle })
    })
        .then(response => {
            if (response.status === 404) {
                throw new Error('Book not found!');
            }
            return response.text();
        })
        .then(xmlString => {
            const parser = new DOMParser();
            const xmlDoc = parser.parseFromString(xmlString, "text/xml");

            const title = xmlDoc.getElementsByTagName("Title")[0].textContent;
            const price = xmlDoc.getElementsByTagName("Price")[0].textContent;

            document.getElementById('result').innerHTML = `
            <strong>Title:</strong> ${title}<br>
            <strong>Price:</strong> ${price}
        `;
        })
        .catch(error => {
            document.getElementById('result').textContent = error.message;
        });
});
