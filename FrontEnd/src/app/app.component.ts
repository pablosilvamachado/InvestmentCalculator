import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { CdbService} from '../services/api.service';
import { CdbResultado } from '../app/models/cdb-resultado';
import { FormsModule, Validator } from '@angular/forms';

@Component({
  standalone: true,
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  imports: [ReactiveFormsModule, CommonModule, HttpClientModule, FormsModule],
})
export class AppComponent {
  cdbForm: FormGroup;
  resultado: any[] = []
  resultadoTotal:{ [key: string]: number } | null = null;
  resultados: CdbResultado | null = null;

  mostrarDetalhes: boolean = false;


  constructor(private fb: FormBuilder, private cdbService: CdbService) {
    this.cdbForm = this.fb.group({
      valorInicial: [
        '',
        [Validators.required, Validators.min(0.01)], // Valor inicial não pode ser negativo ou zero
      ],
      prazo: [
        '',
        [Validators.required, Validators.min(2)], // Prazo em meses deve ser maior ou igual a 1
      ],
    });
  }

  onSubmit() {
    this.resultado = [];
    this.resultadoTotal = null; 
    this.resultado = [];

    const valorInicial = this.cdbForm.value.valorInicial;
    const prazo = this.cdbForm.value.prazo;

    this.cdbService.calcularCdb(valorInicial, prazo).subscribe(response => {
      this.resultados = response;

      let valorInvestTotalBruto = this.resultados.valorFinalBruto;
      let valorInvestTotalLiquido = this.resultados.valorFinalLiquido;
      
      this.resultados = {
        valorFinalBruto: valorInvestTotalBruto,
        valorFinalLiquido: valorInvestTotalLiquido
      }    

    }, error => {
      console.error('Erro ao calcular CDB:', error);
    });    
  
  }

  totais() {   
    return this.resultadoTotal;
  } 

  hasError(controlName: string, errorName: string): boolean {
    return this.cdbForm.controls[controlName].hasError(errorName);
  }
}
