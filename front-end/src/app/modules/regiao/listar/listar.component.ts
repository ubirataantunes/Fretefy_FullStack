import { AfterViewInit, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RegiaoService } from 'src/app/services/regiao.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-listar',
  templateUrl: './listar.component.html',
  styleUrls: ['./listar.component.scss'],
})
export class ListarComponent implements OnInit {
  regioes: any[] = [];

  constructor(private regiaoService: RegiaoService, private router: Router) { }

  ngOnInit(): void {
    this.listar();
  }

  listar() {
    this.regiaoService.listarTodos().subscribe((data) => {
      this.regioes = data;
    }, (error) => {
      console.error('Erro ao listar regiões:', error);
      Swal.fire({
        icon: 'error',
        title: 'Erro',
        text: 'Não foi possível carregar as regiões.',
        confirmButtonText: 'OK',
        confirmButtonColor: '#333',
      });
    });
  }

  ativar(regiao: any): void {
    this.regiaoService.ativar(regiao.id).subscribe(
      () => {
        regiao.ativo = true;
      },
      (error) => {
        console.error(error);
        Swal.fire({
          icon: 'error',
          title: 'Erro',
          text: 'Não foi possível ativar a região.',
          confirmButtonText: 'OK',
          confirmButtonColor: '#333',
        });
      }
    );
  }

  desativar(regiao: any): void {
    this.regiaoService.desativar(regiao.id).subscribe(
      () => {
        regiao.ativo = false;
      },
      (error) => {
        console.error(error);
        Swal.fire({
          icon: 'error',
          title: 'Erro',
          text: 'Não foi possível desativar a região.',
          confirmButtonText: 'OK',
          confirmButtonColor: '#333',
        });
      }
    );
  }

  cadastrar(): void {
    this.router.navigate(['/regiao/cadastrar']);
  }

  editar(id: string) {
    this.router.navigate([`/regiao/editar/${id}`]);
  }

  async excluir(id: string): Promise<void> {
    const result = await Swal.fire({
      title: 'Tem certeza?',
      text: 'Esta ação não poderá ser revertida!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Sim, excluir!',
      cancelButtonText: 'Cancelar',
      confirmButtonColor: '#bd3939ff',
      cancelButtonColor: '#949899',
    });

    if (!result.isConfirmed) {
      return;
    }

    this.regiaoService.deletar(id).subscribe(() => {

      this.regioes = this.regioes.filter((regiao) => regiao.id !== id);

      Swal.fire({
        title: 'Excluído!',
        text: 'A região foi excluída com sucesso.',
        icon: 'success',
        confirmButtonColor: '#3085d6',
      });

    }, (error) => {
      console.error('Erro ao excluir a região:', error);

      Swal.fire({
        title: 'Erro!',
        text: 'Não foi possível excluir a região. Tente novamente.',
        icon: 'error',
        confirmButtonColor: '#d33',
      });
    });
  }

  exportar() {
    this.regiaoService.exportar().subscribe(
      (data) => {
        const fileContents = data.fileContents;
        const contentType = data.contentType || 'text/csv';
        const fileDownloadName = data.fileDownloadName || 'arquivo.csv';

        const byteCharacters = atob(fileContents);
        const byteNumbers = new Array(byteCharacters.length);
        for (let i = 0; i < byteCharacters.length; i++) {
          byteNumbers[i] = byteCharacters.charCodeAt(i);
        }
        const byteArray = new Uint8Array(byteNumbers);

        const blob = new Blob([byteArray], { type: contentType });
        const url = window.URL.createObjectURL(blob);
        const a = document.createElement('a');
        a.href = url;
        a.download = fileDownloadName;
        document.body.appendChild(a);
        a.click();
        document.body.removeChild(a);
        window.URL.revokeObjectURL(url);
      },
      (error) => {
        console.error('Erro ao exportar regiões:', error);
        Swal.fire({
          icon: 'error',
          title: 'Erro',
          text: 'Não foi possível exportar as regiões.',
          confirmButtonText: 'OK',
          confirmButtonColor: '#333',
        });
      }
    );
  }
}
