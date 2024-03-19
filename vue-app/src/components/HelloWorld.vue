<template>
  <div>

    <ul>
      <li v-for="todo in todos" v-bind:key="todo.id"> <!-- use a real id field (todo.id) to prevent problems when todos have the same text -->
        <input type="checkbox" v-model="todo.done"><!-- checkbox for marking as done, bind to the "done" field in vuejs model -->
        {{ todo.text }}</li>
    </ul>

    <form v-on:submit.prevent="addTodo">
      <input v-model="todoText" placeholder="What needs to be done?">
      <button type="submit">Add Todo</button>
    </form>

  </div>
</template>

<script>
export default {
  name: "HelloWorld",
  data: function () {
    return {
      todos: [],
      todoText: '',
    };
  },
  methods: {
    addTodo: function () {
      var newTodo = {
        text: this.todoText,
        done: false,
        id: Date.now(), // not great, but good enough for this example
      }
      this.todos.push(newTodo);
    },
  },
  watch: { // überwachungen
       todos: { //welches objekt überwacht wird: "todos" liste
        handler(oldTodos, newTodos) {
          console.log("detected update of todos:", oldTodos, newTodos);
          localStorage.setItem('todos', JSON.stringify(newTodos));  // todos neu speichern
        },
        deep: true, // änderungen des kompletten todo objekts werden überwacht
      },
  },
  mounted: function () {
    const existingTodos = localStorage.getItem('todos');
    this.todos = JSON.parse(existingTodos) || [];
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
