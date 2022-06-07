import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  @Output() toggleSidebarForMe: EventEmitter<any> = new EventEmitter();

  constructor(private http: HttpClient, private header: HttpHeaders) { }

  ngOnInit(): void {
  }

  urlPhoto !: string;

  userName = 'Đỗ Khắc Phong';

  roleName = "Developer"

  getPhoto(id : string)
  {
    return this.http.get(`http://localhost:48608/FileManager/${id}`, {responseType: 'blob'})
    .subscribe((result: Blob) => {
      const blob = new Blob([result], { type: this.header.get('content-type')! }); // you can change the type
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
}
