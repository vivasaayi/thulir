import {Home} from './components/Home';
import {LandsatDataSetBrowser} from './components/LandsatDataSetBrowser';
import {CatalogBuilder} from './components/CatalogBuilder';
import {ThulirDataSetBrowser} from './components/ThulirDataSetBrowser';
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
  },
  {
    path: '/thulir-dataset-browser',
    element: <ThulirDataSetBrowser />
  }
];

export default AppRoutes;
