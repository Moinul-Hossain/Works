const Note = require("../models/note.model.js");

// Create and Save a new note
exports.create = (req, res) => {
  
    // Validate request
    if (!req.body) {
        res.status(400).send({
        message: "Content cannot be empty!"
        });
    }

    // Create a Note
    const note = new Note({
        uid: req.body.uid,
        record_txt: req.body.record_txt
    });

    // Save Note in the database
    Note.create(note, (err, data) => {
        if (err)
        res.status(500).send({
            message:
            err.message || "Error occurred while creating the note!"
        });
        else res.send(data);
    });

};

// Retrieve all notes from the database.
exports.findAll = (req, res) => {
    Note.getAll((err, data) => {
        if (err)
          res.status(500).send({
            message:
              err.message || "Some error occurred while retrieving notes."
          });
        else res.send(data);
      });
};

// Find a single note with a noteId
exports.findOne = (req, res) => {
    Note.findById(req.params.noteId, (err, data) => {
        if (err) {
          if (err.kind === "not_found") {
            res.status(404).send({
              message: `Not found note with id ${req.params.noteId}.`
            });
          } else {
            res.status(500).send({
              message: "Error retrieving note with id " + req.params.noteId
            });
          }
        } else res.send(data);
      });
};

// Delete a note with the specified noteId in the request
exports.delete = (req, res) => {
    Note.remove(req.params.noteId, (err, data) => {
        if (err) {
          if (err.kind === "not_found") {
            res.status(404).send({
              message: `Not found note with id ${req.params.noteId}.`
            });
          } else {
            res.status(500).send({
              message: "Could not delete note with id " + req.params.noteId
            });
          }
        } else res.send({ message: `Note was deleted successfully!` });
      });
};