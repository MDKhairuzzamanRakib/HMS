import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ButtonModule } from 'primeng/button';
import { DividerModule } from 'primeng/divider';
import { RippleModule } from 'primeng/ripple';
import { StyleClassModule } from 'primeng/styleclass';
import { FeaturesWidget } from '../../landing/components/featureswidget';
import { FooterWidget } from '../../landing/components/footerwidget';
import { HeroWidget } from '../../landing/components/herowidget';
import { HighlightsWidget } from '../../landing/components/highlightswidget';
import { PricingWidget } from '../../landing/components/pricingwidget';
import { TopbarWidget } from '../../landing/components/topbarwidget.component';

@Component({
  selector: 'app-home-page',
  imports: [RouterModule, TopbarWidget, HeroWidget, FeaturesWidget, HighlightsWidget, PricingWidget, FooterWidget, RippleModule, StyleClassModule, ButtonModule, DividerModule],
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.scss'
})
export class HomePageComponent {

}
