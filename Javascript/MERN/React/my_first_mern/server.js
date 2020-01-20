const express = require('express');
const cors = require('cors');
const app = express();
app.use(cors());

require('./server/routes/person.routes')(app);



app.listen(8000, () => {
    console.log("You are now listening on port 8000");
})