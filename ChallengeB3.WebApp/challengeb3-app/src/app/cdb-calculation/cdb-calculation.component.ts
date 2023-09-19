import { Component } from '@angular/core';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule, NgIf } from '@angular/common';
import { CurrencyMaskModule } from 'ng2-currency-mask';
import { MatIconModule } from '@angular/material/icon';
import { MatDividerModule } from '@angular/material/divider';
import { MatButtonModule } from '@angular/material/button';
import { CdbserviceService } from '../Services/cdbservice.service';
import { MatDialog,  MatDialogModule } from '@angular/material/dialog';



@Component({
  selector: 'app-cdb-calculation',
  templateUrl: './cdb-calculation.component.html',
  styleUrls: ['./cdb-calculation.component.css'],
  standalone: true,
  imports: [MatFormFieldModule, MatInputModule, MatButtonModule, FormsModule, ReactiveFormsModule, CommonModule, NgIf, CurrencyMaskModule, MatDividerModule, MatIconModule, MatDialogModule],
})
export class CdbCalculationComponent  {

  public addcalulateCdbFormGroup: FormGroup | undefined;
  public showResult: boolean | undefined ;
  public netIncome: number | undefined;
  public grossIncome: number | undefined;

  constructor(private cdbService: CdbserviceService
    , public dialog: MatDialog  ) {
    this.addcalulateCdbFormGroup = new FormGroup({
      valueToInvest: new FormControl('', [Validators.required, Validators.min(1)]),
      monthToInvest: new FormControl('', [Validators.required, Validators.min(2)]),
    });
  }


  public checkError = (controlName: string, errorName: string) => {
    return this.addcalulateCdbFormGroup?.controls[controlName].hasError(errorName);
  }

  closeDialog() { 
    this.addcalulateCdbFormGroup?.controls['valueToInvest'].setValue(1);
    this.addcalulateCdbFormGroup?.controls['monthToInvest'].setValue(2);
    this.showResult = false;
    this.netIncome = 0;
    this.grossIncome = 0;
  }

  onSubmit() {
    this.cdbService.getCalculateCdb(this.addcalulateCdbFormGroup?.controls['valueToInvest'].value, this.addcalulateCdbFormGroup?.controls['monthToInvest'].value)
      .subscribe((result) => {
        console.log(result);
        this.showResult = true;
        this.netIncome = result.netIncome;
        this.grossIncome = result.grossIncome;
      });
  }
}
