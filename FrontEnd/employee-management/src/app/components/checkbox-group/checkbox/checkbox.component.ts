import { Component, Host, Input } from '@angular/core';
import { CheckboxGroupComponent } from '../checkbox-group.component';

@Component({
  selector: 'app-checkbox',
  standalone: true,
  templateUrl: './checkbox.component.html',
  styleUrls: ['./checkbox.component.scss'],
})
export class CheckboxComponent {
  @Input() value: string;
  @Input() label: string;

  constructor(@Host() public checkboxGroup: CheckboxGroupComponent) {}
}
