import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { url } from 'src/app/consts/url';
import { Observable } from 'rxjs';
import { ProjectTime } from '../consts/projectTime';

@Injectable({
  providedIn: 'root',
})
export class APIcallsService {
  constructor(private http: HttpClient) {}

  public getAllProjectTimes(): Observable<ProjectTime[]> {
    return this.http.get<ProjectTime[]>(`${url}` + 'projectTime');
  }

  public addStartingTime(): Observable<ProjectTime> {
    return this.http.post<ProjectTime>(`${url}`, null);
  }

  public addNewProject(projectName: string): Observable<ProjectTime> {
    return this.http.put<ProjectTime>(`${url}`, projectName);
  }

  public editProjectTime(projectName: string): Observable<ProjectTime> {
    return this.http.patch<ProjectTime>(`${url}`, projectName);
  }

  public deleteProjectTime(id: number): Observable<ProjectTime> {
    return this.http.delete<ProjectTime>(`${url}/${id}`);
  }
}
