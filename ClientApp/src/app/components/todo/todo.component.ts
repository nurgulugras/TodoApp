import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Todo } from 'src/app/models/todo';
import { TodoService } from 'src/app/services/todo.service';

@Component({
  selector: 'app-todo',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.css']
})
export class TodoComponent implements OnInit {

   //  #region [ Fields ]
   todoArray:Todo[]=[];
   selectedTodo:Todo=new Todo();
   addTodoValue : string = '';
  // #endregion

  //  #region [ Initialize ]
  constructor(private todoService:TodoService) { }

  ngOnInit() {
    this.getTodoFromAPI();
  }
  // #endregion

  //  #region [ Entity ]
  deleteTodoFromAPI(todo: Todo) {
    this.todoService
      .deleteTodo(todo.id)
      .subscribe((response) => {
        
       console.log("success")
       this.refresh();

      });
  }
  saveTodoFromAPI() {
    this.selectedTodo.content = this.addTodoValue;
    this.todoService
      .addTodo(this.selectedTodo)
      .subscribe((response) => {
        console.log("success")
        this.refresh();
      
      });
  }
  getTodoFromAPI() {
    this.todoService.getTodos().subscribe((response) => {
      this.todoArray=response;
      console.log("success")
    });
  }
  // #endregion

  //  #region [ UI Tools ]
  refresh() {
    this.getTodoFromAPI();
  }
  
  // #endregion

  //  #region [ Validations ]
  // #endregion

  //  #region [ Internal ]
  // #endregion

}
