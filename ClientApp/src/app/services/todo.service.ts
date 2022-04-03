import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Todo } from '../models/todo';

@Injectable({
  providedIn: 'root'
})
export class TodoService {
  baseUrl:string="http://localhost:5000/api/todo";

  constructor(private http:HttpClient) {}
   //cars
   getTodos():Observable<Todo[]>{
    return this.http.get<Todo[]>(this.baseUrl);
   }
  //cars/1
   getTodoDetail(id:number):Observable<Todo>{
  
    return this.http.get<Todo>(this.baseUrl+"/"+id);
  }
   addTodo(todo:Todo): Observable<Todo>{
    return this.http.post<Todo>(this.baseUrl,todo);
  }
   deleteTodo(id:number){                                                  
    return this.http.delete(this.baseUrl+"/"+id);
  }
  
}
