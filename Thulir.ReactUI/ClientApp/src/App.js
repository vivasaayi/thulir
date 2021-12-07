import React, {Component} from 'react';
import {Route} from 'react-router';
import {Layout} from './components/Layout';
import {Home} from './components/Home';
import {LandsatDataSetBrowser} from './components/LandsatDataSetBrowser';
import {CatalogBuilder} from './components/CatalogBuilder';
import {LocalizeS3Data} from './components/LocalizeS3Data'
import {TileGenerator} from './components/TileGenerator'

import './custom.css'

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Route exact path='/' component={Home}/>
                <Route path='/catalog-builder' component={CatalogBuilder}/>
                <Route path='/browse-landsat-data' component={LandsatDataSetBrowser}/>
                <Route path='/localize-s3-data' component={LocalizeS3Data}/>
                <Route path='/generate-tiles' component={TileGenerator}/>
            </Layout>
        );
    }
}
