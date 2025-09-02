import { AfterViewInit, Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AtualizarRegiao } from 'src/app/models/atualizarRegiao';
import { Cidade } from 'src/app/models/cidade';
import { Regiao } from 'src/app/models/regiao';
import { RegiaoService } from 'src/app/services/regiao.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-cadastrar',
  templateUrl: './cadastrar.component.html',
  styleUrls: ['./cadastrar.component.scss'],
})
export class CadastrarComponent implements OnInit, AfterViewInit {
  regiaoForm: FormGroup;
  private paramId: string;
  erroAoAddCidade: string;

  get cidades(): FormArray {
    return this.regiaoForm.get('cidades') as FormArray;
  }

  constructor(
    private fb: FormBuilder,
    private regiaoService: RegiaoService,
    public router: Router,
    private route: ActivatedRoute
  ) {}
  ngAfterViewInit(): void {
    if (this.paramId) {
      this.buscarRegiaoPorId();
    }
  }

  ngOnInit(): void {
    this.paramId = this.route.snapshot.paramMap.get('id');

    this.regiaoForm = this.fb.group({
      id: [null],
      nome: [null, [Validators.required]],
      cidades: this.fb.array([this.criarCidadeFormGroup(new Cidade())]),
    });
  }

  buscarRegiaoPorId() {
    this.regiaoService.listarPorId(this.paramId).subscribe(
      (data) => {
        this.cidades.clear();
        data.cidades.forEach((cidade) => {
          this.cidades.push(this.criarCidadeFormGroup(cidade));
        });
        this.regiaoForm.patchValue(data);
      },
      (error) => {
        Swal.fire({
          icon: 'error',
          title: 'Erro',
          text: 'Região não encontrada',
          confirmButtonText: 'OK',
          confirmButtonColor: '#333',
        });
        this.router.navigate(['/regiao/']);
      }
    );
  }

  criarCidadeFormGroup(cidade: Cidade) {
    return this.fb.group({
      id: [cidade.id, [Validators.required]],
      nome: [cidade.nome],
    });
  }

  addCidadeFormGroup() {
    this.erroAoAddCidade = '';
    if (this.cidades.controls[0].get('id').value == '') {
      this.erroAoAddCidade = 'Selecione uma cidade antes de adicionar';
      return;
    }

    this.cidades.push(this.criarCidadeFormGroup(new Cidade()));
  }

  removerCidade(index: number) {
    this.cidades.removeAt(index);
  }

  cancelar() {
    this.router.navigate(['/regiao/']);
  }

  salvar() {
    if (this.regiaoForm.invalid) {
      const totalCidades = this.cidades.controls.filter(
        (p) => p.get('id').value != ''
      ).length;
      if (totalCidades === 0) {
        Swal.fire({
          icon: 'warning',
          title: 'Atenção',
          text: 'Adicione pelo menos uma cidade',
          confirmButtonText: 'OK',
          confirmButtonColor: '#333',
        });
        return;
      }

      Swal.fire({
        icon: 'warning',
        title: 'Atenção',
        text: 'Preencha os campos obrigatórios',
        confirmButtonText: 'OK',
        confirmButtonColor: '#333',
      });
      return;
    }

    if (!this.paramId) {
      var regiaoModel = new Regiao();
      regiaoModel.nome = this.regiaoForm.get('nome').value;
      regiaoModel.cidades = this.cidades.controls.map((p) => p.value);

      this.regiaoService.salvar(regiaoModel).subscribe(
        () => {
          Swal.fire({
            icon: 'success',
            title: 'Sucesso',
            text: 'Região cadastrada com sucesso',
            confirmButtonText: 'OK',
            confirmButtonColor: '#333',
          }).then(() => {
            this.router.navigate(['/regiao/']);
          });
        },
        (error) => {
          error.error.validacoes.forEach((e: string) => {
            Swal.fire({
              icon: 'error',
              title: 'Erro',
              text: e,
              confirmButtonText: 'OK',
              confirmButtonColor: '#333',
            });
          });
        }
      );
    } else {
      var regiaoModelUpdate = new AtualizarRegiao();
      regiaoModelUpdate.id = this.paramId;
      regiaoModelUpdate.nome = this.regiaoForm.get('nome').value;
      regiaoModelUpdate.cidades = this.cidades.controls.map((p) => p.value.id);
      regiaoModelUpdate.ativo = true;
      
      this.regiaoService.atualizar(regiaoModelUpdate).subscribe(
        () => {
          Swal.fire({
            icon: 'success',
            title: 'Sucesso',
            text: 'Região atualizada com sucesso',
            confirmButtonText: 'OK',
            confirmButtonColor: '#333',
          }).then((e) => {
            if (e.dismiss) this.router.navigate(['/regiao/']);
          });
        },
        (error) => {
          error.error.validacoes.forEach((e: string) => {
            Swal.fire({
              icon: 'error',
              title: 'Erro',
              text: e,
              confirmButtonText: 'OK',
              confirmButtonColor: '#333',
            });
          });
        }
      );
    }
  }
}
