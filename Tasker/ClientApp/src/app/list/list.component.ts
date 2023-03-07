import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css'],
})
export class ListComponent implements OnInit {
  public tasks!: Task[];
  public listName: any = 'To-Do List';
  public listId = 0;

  constructor(
    private http: HttpClient
  ) { }

  getTaskList() {
    this.http.get<Task[]>('https://localhost:7042/List/all').subscribe(result => {
      this.tasks = result;
      this.listId = result[0].toDoListId;
      if (result && result[0].toDoList) {
        this.listName = result[0].toDoList.listName;
      }
    }, error => console.error(error));
  }

  ngOnInit() {
    this.getTaskList();
  }

  onAdd(taskName: string) {
    if (taskName === '') return;
    this.http.post(
      'https://localhost:7042/List/add',
      {
        taskName: taskName,
        listId: this.listId
      }
    ).subscribe(result => {
      this.getTaskList();
    }, error => console.error(error));
  }

  onDelete(id: number) {
    this.http.delete(`https://localhost:7042/List/delete/${id}`).subscribe(result => {
      this.getTaskList();
    }, error => console.error(error));
  }
}

interface ToDoList {
  toDoListId: number;
  listName?: string;
  tasks: Task[];
}

interface Task {
  taskId: number;
  taskDescription?: string;
  taskComplete?: boolean;
  toDoListId: number;
  toDoList?: ToDoList;
}
