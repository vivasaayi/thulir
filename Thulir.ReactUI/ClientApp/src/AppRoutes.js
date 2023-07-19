import {Home} from './components/Home';
import {LandsatDataSetBrowser} from './components/LandsatDataSetBrowser';
import {CatalogBuilder} from './components/CatalogBuilder';
import {LocalizeS3Data} from './components/LocalizeS3Data'
import {TileGenerator} from './components/TileGenerator'
import {WeatherViewer} from "./components/WeatherViewer";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/catalog-builder',
    element: <CatalogBuilder />
  }
];

export default AppRoutes;
