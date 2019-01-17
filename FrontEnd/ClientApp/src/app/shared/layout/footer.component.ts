import { Component } from '@angular/core';
import { NewsletterService, Newsletter } from 'src/app/shared/services/newsletter.service';
@Component({
  selector: 'app-layout-footer',
  templateUrl: './footer.component.html'
})
export class FooterComponent {
  today: number = Date.now();
  public newsletterModel: Newsletter;
  constructor(
    private newsletterService: NewsletterService
  ) { }
  ngOnInit() {
    this.newsletterModel = {} as Newsletter;
  }

  async SubscribeNewsletter() {
    await this.newsletterService
      .postNewsletter(this.newsletterModel)
      .subscribe(data => {
        console.log("POST Request is successful ", data);
      },
        error => {
          console.log("Error", error);
      });
  }
}
