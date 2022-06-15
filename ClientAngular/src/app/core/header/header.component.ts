import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { UserServiceService } from 'src/app/services/user-service/user-service.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  @Output() toggleSidebarForMe: EventEmitter<any> = new EventEmitter();

  constructor(private http: HttpClient,private userService: UserServiceService,private route:Router) { }

  ngOnInit(): void {
  }

  urlPhoto !: string;

  userName = 'Đỗ Khắc Phong';

  roleName = "Developer"

  userId: string = window.localStorage.getItem('Id') || '';

  getPhoto() {
    return this.http.get(`http://localhost:5001/FileManager/${this.userId}`, { responseType: 'blob' })
      .subscribe((result: any) => {
        const blob = new Blob([result], { type: result.headers?.get('content-type')! }); // you can change the type
        const uri = window.URL.createObjectURL(blob);
        this.urlPhoto = uri;
        // var img = new Image();
        // img.src = uri;
        // this.urlPhoto = img.src;
      });
  }

  toggleSidebar() {
    this.toggleSidebarForMe.emit();
  }
  logout(){
    this.userService.removeUserLocal();
    this.route.navigateByUrl('/login');
  }
}
