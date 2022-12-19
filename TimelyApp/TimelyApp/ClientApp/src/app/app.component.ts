import { Component, OnInit } from '@angular/core';
import { ProjectTime } from './consts/projectTime';
import { APIcallsService } from './services/apicalls.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent implements OnInit {
  title = 'app';

  buttonText = 'Start';
  public projectTimes!: ProjectTime[];
  public projectTime!: ProjectTime;

  constructor(private apiCallsService: APIcallsService) {}

  ngOnInit(): void {
    this.apiCallsService
      .getAllProjectTimes()
      .subscribe((data) => (this.projectTimes = data));
  }

  postData(element: any) {
    if (element.textContent == 'Start') {
      this.buttonText = 'Stop';

      this.apiCallsService.addStartingTime().subscribe((data) => null);
      this.apiCallsService
        .getAllProjectTimes()
        .subscribe((data) => (this.projectTimes = data));
    } else {
      this.buttonText = 'Start';

      this.apiCallsService
        .getAllProjectTimes()
        .subscribe((data) => (this.projectTimes = data));
    }
  }
}
