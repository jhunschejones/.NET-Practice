"use strict"

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build()

connection.on("RecieveMessage", function (user, message) {
  var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;")
  var encodedMsg = "<span class='text-secondary'>" + user + " says: </span>" + msg
  $("#messageList").append(`<li>${encodedMsg}</li>`)
})

connection.start().catch(function (err) {
  return console.error(err.toString())
})

document.getElementById("sendButton").addEventListener("click", function (event) {
  var user = document.getElementById("userInput").value
  var message = document.getElementById("messageInput").value
  connection.invoke("SendMessage", user, message).catch(function (err) {
    return console.error(err.toString())
  })
  event.preventDefault()
  $('#messageInput').val('')
})