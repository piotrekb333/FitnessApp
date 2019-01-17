import { Component } from '@angular/core';
import { NewsletterService, Newsletter } from 'src/app/shared/services/newsletter.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
declare var jquery: any;
declare var $: any;

@Component({
  selector: 'app-layout-footer',
  templateUrl: './footer.component.html'
})
export class FooterComponent {
  today: number = Date.now();
  registerForm: FormGroup;
  submitted = false;
  public newsletterModel: Newsletter;
  constructor(
    private newsletterService: NewsletterService,
    private formBuilder: FormBuilder
  ) { }
  ngOnInit() {
    this.newsletterModel = {} as Newsletter;
    this.registerForm = this.formBuilder.group({
      txtNewsletter: ['', [Validators.required, Validators.email]],
    });
  }
  get f() {
    return this.registerForm.controls;
  }
  async SubscribeNewsletter() {
    debugger;
    this.submitted = true;
    if (this.registerForm.invalid) {
      return;
    }
    await this.newsletterService
      .postNewsletter(this.newsletterModel)
      .subscribe(data => {
        $.alert({
          title: 'Sukces!',
          content: 'Zapisano pomyślnie',
        });
      },
      error => {
        $.alert({
          title: 'Błąd!',
          content: 'Wystąpił błąd!',
        });
          console.log("Error", error);
      });
  }
}
