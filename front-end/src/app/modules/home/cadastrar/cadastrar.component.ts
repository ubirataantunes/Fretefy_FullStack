import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Cidade } from 'src/app/models/cidade';
import { Regiao } from 'src/app/models/regiao';
import { CidadeService } from 'src/app/services/cidade.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-cadastrar',
  templateUrl: './cadastrar.component.html',
  styleUrls: ['./cadastrar.component.scss'],
})
export class CadastrarComponent implements OnInit {
  cidadeForm: FormGroup;
  private paramId: string;
  erroAoAddCidade: string;

  constructor(
    private fb: FormBuilder,
    private cidadeService: CidadeService,
    public router: Router
  ) {
    this.cidadeForm = this.fb.group({
      nome: [null, [Validators.required]],
      uf: [null, [Validators.required]],
    });
  }

  ngOnInit(): void {}

  salvar() {
    if (this.cidadeForm.valid) {
      const cidade: Cidade = this.cidadeForm.value;
      this.cidadeService.cadastrar(cidade).subscribe(
        (data) => {
          Swal.fire({
            icon: 'success',
            title: 'Sucesso',
            text: 'Região cadastrada com sucesso.',
            confirmButtonText: 'OK',
            confirmButtonColor: '#333',
          }).then((e) => {
            if (e.isConfirmed) this.router.navigate(['/regioes']);
          });
        },
        (error) => {
          console.error('Erro ao cadastrar região:', error);
          Swal.fire({
            icon: 'error',
            title: 'Erro',
            text: 'Não foi possível cadastrar a região.',
            confirmButtonText: 'OK',
            confirmButtonColor: '#333',
          });
        }
      );
    } else {
      Swal.fire({
        icon: 'warning',
        title: 'Atenção',
        text: 'Preencha todos os campos obrigatórios.',
        confirmButtonText: 'OK',
        confirmButtonColor: '#333',
      });
    }
  }

  cancelar() {
    this.router.navigate(['/home']);
  }
}
