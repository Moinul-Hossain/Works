const sql = require("./db.js");

// constructor
const Note = function(Note) {
  this.uid = Note.uid;
  this.record_txt = Note.record_txt;
};

Note.create = (newNote, result) => {
  
    let insertQuery = 'INSERT INTO notes (uid, record_txt) VALUES (?,?)';
    let query = sql.format(insertQuery,[newNote.uid, newNote.record_txt]);

    sql.query(query,(err, response) => {
        if(err) {
            console.error(err);
            return;
        }
        // rows added
        console.log(response.insertId);
    });


  /*
  sql.query("INSERT INTO Notes (uid, record_txt) VALUES (?, ?)", newNote, (err, res) => {
    if (err) {
      console.log("error: ", err);
      result(err, null);
      return;
    }

    console.log("Created note: ", { id: res.insertId, ...newNote });
    result(null, { id: res.insertId, ...newNote });
  });
  */
  
};

Note.findById = (NoteId, result) => {
  sql.query(`SELECT * FROM Notes WHERE id = ${NoteId}`, (err, res) => {
    if (err) {
      console.log("error: ", err);
      result(err, null);
      return;
    }

    if (res.length) {
      console.log("found Note: ", res[0]);
      result(null, res[0]);
      return;
    }

    // not found Note with the id
    result({ kind: "not_found" }, null);
  });
};

Note.getAll = result => {
  sql.query("SELECT * FROM Notes", (err, res) => {
    if (err) {
      console.log("error: ", err);
      result(null, err);
      return;
    }

    console.log("Notes: ", res);
    result(null, res);
  });
};

Note.remove = (id, result) => {
  sql.query("DELETE FROM Notes WHERE id = ?", id, (err, res) => {
    if (err) {
      console.log("error: ", err);
      result(null, err);
      return;
    }

    if (res.affectedRows == 0) {
      // not found Note with the id
      result({ kind: "not_found" }, null);
      return;
    }

    console.log("Deleted note with id: ", id);
    result(null, res);
  });
};

module.exports = Note;