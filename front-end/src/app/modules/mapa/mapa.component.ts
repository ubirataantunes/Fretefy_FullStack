import { Component, OnInit } from '@angular/core';
import { Cidade } from 'src/app/models/cidade';
import { CidadeService } from 'src/app/services/cidade.service';
import Swal from 'sweetalert2';
import * as L from 'leaflet';

@Component({
  selector: 'app-mapa',
  templateUrl: './mapa.component.html',
  styleUrls: ['./mapa.component.scss'],
})
export class MapaComponent implements OnInit {
  private map!: L.Map;
  cidades: Cidade[] = [];

  constructor(private cidadeService: CidadeService) {}

  ngOnInit() {
    this.buscarCidades();
  }

  buscarCidades() {
    this.cidadeService.listarTodos().subscribe(
      (data: Cidade[]) => {
        this.cidades = data;
        this.inicializarMapa();
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

  inicializarMapa() {
    if (this.map) {
      this.map.remove(); 
    }

    this.map = L.map('map').setView([-15.7797, -47.9297], 4);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      attribution: '&copy; OpenStreetMap contributors',
    }).addTo(this.map);

    this.cidades.forEach((cidade) => {
      if (cidade.latitude && cidade.longitude) {
        L.marker([cidade.latitude, cidade.longitude])
          .addTo(this.map)
          .bindPopup(`<strong>${cidade.nome} - ${cidade.uf}</strong>`);
      }
    });
  }
}
