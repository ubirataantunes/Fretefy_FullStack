import { AfterViewInit, Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import { Cidade } from 'src/app/models/cidade';
import { CidadeService } from 'src/app/services/cidade.service';
import Swal from 'sweetalert2';
import * as L from 'leaflet';

delete (L.Icon.Default.prototype as any)._getIconUrl;

L.Icon.Default.mergeOptions({
  iconRetinaUrl: 'assets/images/marker-icon-2x.png',
  iconUrl: 'assets/images/marker-icon.png',
  shadowUrl: 'assets/images/marker-shadow.png',
});

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  map!: L.Map;
  miniMap!: L.Map;
  cidades: Cidade[] = [];
  cidadeComMapaVisivel: Cidade | null = null;

  constructor(private cidadeService: CidadeService, private router: Router) {}

  ngOnInit() {
    this.buscarCidades();
  }

  cadastrar(): void {
    this.router.navigate(['/home/cadastrar']);
  }

  buscarCidades() {
    this.cidadeService.listarTodos().subscribe(
      (data: Cidade[]) => {
        this.cidades = data;
      },
      (error) => {
        console.error('Erro ao buscar cidades:', error);
        Swal.fire({
          icon: 'error',
          title: 'Erro',
          text: 'Não foi possível carregar as cidades.',
          confirmButtonText: 'OK',
          confirmButtonColor: '#333',
        });
      }
    );
  }

  atualizarLatitudeELongitude() {
    this.cidadeService.atualizarLatitudeELongitude().subscribe(
      (data: Cidade[]) => {
        this.cidades = data;
        Swal.fire({
          icon: 'success',
          title: 'Sucesso',
          text: 'Latitude e Longitude atualizadas com sucesso.',
          confirmButtonText: 'OK',
          confirmButtonColor: '#333',
        });
      },
      (error) => {
        console.error('Erro ao atualizar latitude e longitude:', error);
        Swal.fire({
          icon: 'error',
          title: 'Erro',
          text: 'Não foi possível atualizar as coordenadas.',
          confirmButtonText: 'OK',
          confirmButtonColor: '#333',
        });
      }
    );
  }

  mostrarMiniMapa(cidade: Cidade): void {
    this.cidadeComMapaVisivel = cidade;

    setTimeout(() => {
      const mapId = 'mini-map-' + cidade.nome.replace(/\s+/g, '-');
      const container = document.getElementById(mapId);

      if (container) {
        this.miniMap = L.map(container, {
          attributionControl: false,
          zoomControl: true,
          dragging: false,
          scrollWheelZoom: false,
          doubleClickZoom: false,
          boxZoom: false,
          keyboard: false,
          tap: false,
        }).setView([cidade.latitude!, cidade.longitude!], 10);

        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
          attribution: '',
        }).addTo(this.miniMap);

        L.marker([cidade.latitude!, cidade.longitude!]).addTo(this.miniMap);
      }
    }, 50);
  }

  ocultarMiniMapa(): void {
    this.cidadeComMapaVisivel = null;
    if (this.miniMap) {
      this.miniMap.remove();
    }
  }
}
