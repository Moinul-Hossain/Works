module.exports = app => {
  const notes = require("../controllers/note.controller.js");

  // Create a new note
  app.post("/notes", notes.create);

  // Retrieve all notes
  app.get("/notes", notes.findAll);

  // Retrieve a single note with noteId
  app.get("/notes/:noteId", notes.findOne);

  // Delete a note with noteId
  app.delete("/notes/:noteId", notes.delete);

};