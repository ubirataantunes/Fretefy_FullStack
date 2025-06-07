import { Component, forwardRef, Input, OnInit } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { Cidade } from 'src/app/models/cidade';
import { CidadeService } from 'src/app/services/cidade.service';

@Component({
  selector: 'app-cidade-select',
  templateUrl: './cidade-select.component.html',
  styleUrls: ['./cidade-select.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => CidadeSelectComponent),
      multi: true
    }
  ]
})
export class CidadeSelectComponent implements ControlValueAccessor {

  value: string = '';
  onChange: any = () => {};
  onTouched: any = () => {};

  public cidades: Cidade[];

  constructor(private cidadeService: CidadeService) { 
    this.listarCidades();
  }

  listarCidades() {
    this.cidadeService.listarTodos().subscribe((data) => {
      this.cidades = data;
    });
  }

  writeValue(value: any): void {
    this.value = value;
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  setValue(val: any) {
    this.value = val;
    this.onChange(val);
    this.onTouched();
  }
}

  
