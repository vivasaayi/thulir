import React, {Component, useState} from 'react';
import {
    CForm,
    CFormSelect,
    CButton,
    CFormLabel,
    CFormInput,
    CRow,
    CCol,
    CContainer,
    CCard,
    CCardImage,
    CModal,
    CModalHeader,
    CModalTitle,
    CModalBody,
    CModalFooter
} from '@coreui/react';
import {Row} from "reactstrap";

const cardImageCss = {
    "padding": "2px"
}

const cardCss = {
    'width': '9rem',
    'flex-direction': 'row'
}

export class TileGenerator extends Component {
    static displayName = TileGenerator.name;

    constructor(props) {
        super(props);
        this.state = {
            modalVisible: false,
            totalRendered: 10,
            file: "LC08_L2SP_144052_20211028_20211104_02_T1"
        };

        this.getDataSets();
    }

    componentDidMount() {

    }

    componentDidUpdate(prevProps, prevState, snapshot) {

    }

    renderControls() {
        // TODO: Generate years it programmatically
        return <div>
            <CForm>
                <CContainer>
                    <CRow>
                        <CCol size="sm">
                            <CButton color="primary" onClick={() => this.generateTiles()}>Generate Tiles</CButton>
                        </CCol>
                    </CRow>
                    <CRow>
                        <CCol size="sm">
                            {JSON.stringify(this.state.pendingFiles)}
                        </CCol>
                    </CRow>
                </CContainer>
            </CForm>

        </div>;
    }

    async generateTiles() {
        try {
            const response = await fetch(`/api/landsattilegenerator/generate-tiles`);
            const data = await response.json();
            this.setState({pendingFiles: data, loading: false});
        } catch (ex) {
            console.log(ex)
        }
    }

    async getDataSets() {
        try {
            // const response = await fetch(`/api/landsattilegenerator/get-datasets`);
            setTimeout(() => {
                const data = ["LC08_L2SP_144052_20170102_20200905_02_T1", "LC08_L2SP_144052_20170118_20200905_02_T1", "LC08_L2SP_144052_20170203_20200905_02_T1", "LC08_L2SP_144052_20170219_20200905_02_T1", "LC08_L2SP_144052_20170307_20200905_02_T1", "LC08_L2SP_144052_20170323_20200904_02_T1", "LC08_L2SP_144052_20170408_20200904_02_T1", "LC08_L2SP_144052_20170424_20200904_02_T1", "LC08_L2SP_144052_20170510_20200904_02_T1", "LC08_L2SP_144052_20170526_20200903_02_T1", "LC08_L2SP_144052_20170611_20200903_02_T1", "LC08_L2SP_144052_20170627_20200903_02_T1", "LC08_L2SP_144052_20170713_20200903_02_T1", "LC08_L2SP_144052_20170729_20200903_02_T1", "LC08_L2SP_144052_20170814_20200903_02_T1", "LC08_L2SP_144052_20170830_20200903_02_T1", "LC08_L2SP_144052_20170915_20200903_02_T1", "LC08_L2SP_144052_20171001_20200903_02_T1", "LC08_L2SP_144052_20171017_20200902_02_T1", "LC08_L2SP_144052_20171102_20200902_02_T1", "LC08_L2SP_144052_20171118_20200902_02_T1", "LC08_L2SP_144052_20171204_20200902_02_T1", "LC08_L2SP_144052_20171220_20200902_02_T1", "LC08_L2SP_144052_20180105_20200902_02_T1", "LC08_L2SP_144052_20180121_20200902_02_T1", "LC08_L2SP_144052_20180206_20200902_02_T1", "LC08_L2SP_144052_20180222_20200902_02_T1", "LC08_L2SP_144052_20180310_20200901_02_T1", "LC08_L2SP_144052_20180326_20200901_02_T1", "LC08_L2SP_144052_20180411_20200901_02_T1", "LC08_L2SP_144052_20180427_20200901_02_T1", "LC08_L2SP_144052_20180513_20200901_02_T1", "LC08_L2SP_144052_20180529_20200901_02_T1", "LC08_L2SP_144052_20180614_20200831_02_T2", "LC08_L2SP_144052_20180630_20200831_02_T1", "LC08_L2SP_144052_20180716_20200831_02_T2", "LC08_L2SP_144052_20180801_20200831_02_T1", "LC08_L2SP_144052_20180817_20200831_02_T1", "LC08_L2SP_144052_20180902_20200831_02_T1", "LC08_L2SP_144052_20180918_20200830_02_T1", "LC08_L2SP_144052_20181004_20200830_02_T2", "LC08_L2SP_144052_20181020_20200830_02_T1", "LC08_L2SP_144052_20181105_20200830_02_T1", "LC08_L2SP_144052_20181121_20200830_02_T1", "LC08_L2SP_144052_20181207_20200830_02_T1", "LC08_L2SP_144052_20181223_20200830_02_T1", "LC08_L2SP_144052_20190108_20200829_02_T1", "LC08_L2SP_144052_20190124_20200830_02_T1", "LC08_L2SP_144052_20190209_20200829_02_T1", "LC08_L2SP_144052_20190225_20200829_02_T1", "LC08_L2SP_144052_20190313_20200829_02_T1", "LC08_L2SP_144052_20190329_20200829_02_T1", "LC08_L2SP_144052_20190414_20200828_02_T1", "LC08_L2SP_144052_20190430_20200829_02_T1", "LC08_L2SP_144052_20190516_20200828_02_T1", "LC08_L2SP_144052_20190601_20200828_02_T1", "LC08_L2SP_144052_20190617_20200827_02_T1", "LC08_L2SP_144052_20190703_20200827_02_T1", "LC08_L2SP_144052_20190719_20200827_02_T1", "LC08_L2SP_144052_20190804_20200827_02_T1", "LC08_L2SP_144052_20190820_20200827_02_T1", "LC08_L2SP_144052_20190905_20200826_02_T2", "LC08_L2SP_144052_20190921_20200826_02_T1", "LC08_L2SP_144052_20191007_20200825_02_T1", "LC08_L2SP_144052_20191023_20200825_02_T1", "LC08_L2SP_144052_20191108_20200825_02_T1", "LC08_L2SP_144052_20191124_20200825_02_T1", "LC08_L2SP_144052_20191210_20200824_02_T1", "LC08_L2SP_144052_20191226_20200824_02_T1", "LC08_L2SP_144052_20200111_20200823_02_T1", "LC08_L2SP_144052_20200127_20200823_02_T1", "LC08_L2SP_144052_20200212_20200823_02_T1", "LC08_L2SP_144052_20200228_20200822_02_T1", "LC08_L2SP_144052_20200315_20200822_02_T1", "LC08_L2SP_144052_20200331_20200822_02_T1", "LC08_L2SP_144052_20200416_20200822_02_T1", "LC08_L2SP_144052_20200502_20200820_02_T1", "LC08_L2SP_144052_20200518_20200820_02_T1", "LC08_L2SP_144052_20200603_20200824_02_T1", "LC08_L2SP_144052_20200619_20200823_02_T1", "LC08_L2SP_144052_20200705_20200913_02_T1", "LC08_L2SP_144052_20200721_20200911_02_T1", "LC08_L2SP_144052_20200806_20200916_02_T1", "LC08_L2SP_144052_20200822_20200905_02_T1", "LC08_L2SP_144052_20200907_20200918_02_T1", "LC08_L2SP_144052_20200923_20201006_02_T1", "LC08_L2SP_144052_20201009_20201016_02_T1", "LC08_L2SP_144052_20201025_20201106_02_T1", "LC08_L2SP_144052_20201110_20210316_02_T1", "LC08_L2SP_144052_20201126_20210316_02_T1", "LC08_L2SP_144052_20201212_20210313_02_T1", "LC08_L2SP_144052_20201228_20210310_02_T1", "LC08_L2SP_144052_20210113_20210308_02_T1", "LC08_L2SP_144052_20210214_20210301_02_T1", "LC08_L2SP_144052_20210302_20210312_02_T1", "LC08_L2SP_144052_20210318_20210328_02_T1", "LC08_L2SP_144052_20210403_20210409_02_T1", "LC08_L2SP_144052_20210419_20210424_02_T1", "LC08_L2SP_144052_20210505_20210517_02_T1", "LC08_L2SP_144052_20210521_20210529_02_T1", "LC08_L2SP_144052_20210606_20210615_02_T1", "LC08_L2SP_144052_20210622_20210629_02_T1", "LC08_L2SP_144052_20210708_20210713_02_T1", "LC08_L2SP_144052_20210724_20210730_02_T1",
                    "LC08_L2SP_144052_20210809_20210819_02_T1", "LC08_L2SP_144052_20210825_20210901_02_T1", "LC08_L2SP_144052_20210910_20210916_02_T1", "LC08_L2SP_144052_20210926_20211001_02_T1", "LC08_L2SP_144052_20211012_20211019_02_T1", "LC08_L2SP_144052_20211028_20211104_02_T1", "LC08_L2SP_144052_20211113_20211125_02_T2"];
                this.setState({datasets: data.reverse()});
            }, 500);

        } catch (ex) {
            console.log(ex)
        }
    }

    renderBands() {
        if (!this.state.datasets) {
            return <div>Loading DataSets</div>;
        }
        const cols = []
        for (var i = 0; i < this.state.totalRendered; i++) {
            const file = this.state.datasets[i];

            cols.push(
                <CRow>
                    <CCol>
                        {file}
                    </CCol>
                    <CCol>
                        <CCard style={cardCss}>
                            {/*<CCardImage style={cardImageCss} orientation="top" src={`https://52.11.253.156/landsat-tile/${this.state.file}_SR_B1.png`}/>*/}
                            <CCardImage style={cardImageCss} onClick={(e) => this.onImageClicked(e)} orientation="top"
                                        src={`https://52.11.253.156/landsat-tile/${file}_SR_B2.png`}/>
                            <CCardImage style={cardImageCss} onClick={(e) => this.onImageClicked(e)} orientation="top"
                                        src={`https://52.11.253.156/landsat-tile/${file}_SR_B3.png`}/>
                            <CCardImage style={cardImageCss} onClick={(e) => this.onImageClicked(e)} orientation="top"
                                        src={`https://52.11.253.156/landsat-tile/${file}_SR_B4.png`}/>
                            <CCardImage style={cardImageCss} onClick={(e) => this.onImageClicked(e)} orientation="top"
                                        src={`https://52.11.253.156/landsat-tile/${file}_SR_B5.png`}/>
                            <CCardImage style={cardImageCss} onClick={(e) => this.onImageClicked(e)} orientation="top"
                                        src={`https://52.11.253.156/landsat-tile/${file}_SR_B6.png`}/>
                            <CCardImage style={cardImageCss} onClick={(e) => this.onImageClicked(e)} orientation="top"
                                        src={`https://52.11.253.156/landsat-tile/${file}_SR_B7.png`}/>
                            {/*<CCardImage style={cardImageCss} orientation="top" src={`https://52.11.253.156/landsat-tile/${this.state.file}_ST_B10.png`}/>*/}
                        </CCard>
                    </CCol>

                </CRow>
            )
        }
        return <CRow>
            {cols}
        </CRow>
    }

    onImageClicked(e) {
        this.setState({
            selectedImage: e.target.src
        })
        this.setModalVisible(true);
    }

    setModalVisible(value) {
        this.setState({
            modalVisible: value
        });
    }

    renderModal() {
        const visible = this.state.modalVisible;

        return <CModal size="xl" visible={visible} onClose={() => this.setModalVisible(false)}>
            <CModalHeader onClose={() => this.setModalVisible(false)}>
                <CModalTitle>{this.state.selectedImage}</CModalTitle>
            </CModalHeader>
            <CModalBody>
                <CCard>
                    <CCardImage src={this.state.selectedImage}/>
                </CCard>
            </CModalBody>
            <CModalFooter>
                <CButton color="secondary" onClick={() => this.setModalVisible(false)}>
                    Close
                </CButton>
            </CModalFooter>
        </CModal>
    }
    
    renderFooterControls() {
        return <CRow>
            <CCol size="sm">
                <CButton color="primary" onClick={() => this.renderMoreClicked()}>Render More</CButton>
            </CCol>
        </CRow>
    }
    
    renderMoreClicked() {
        this.setState({
            totalRendered: this.state.totalRendered + 5
        })
    }

    render() {
        let controls = this.renderControls();
        let bands = this.renderBands();
        let modal = this.renderModal();
        let footerControls = this.renderFooterControls();

        return (
            <div>
                {modal}
                {controls}
                <hr/>
                {bands}
                <hr/>
                {footerControls}
            </div>
        );
    }
}
