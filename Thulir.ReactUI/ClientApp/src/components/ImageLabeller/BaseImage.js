import React from "react";
import { Image, Layer } from "react-konva";
import useImage from "use-image";

import useStore from "./store";

export default () => {
    const currentImageInfo = useStore(state => state.currentImageInfo);
    
    let imageUrl = "/"
    if(currentImageInfo) {
        imageUrl = `/api/image/render-image-from-s3?id=${currentImageInfo.imageId}`
    }
    
    const [image] = useImage(imageUrl, "Anonymous");

    const setImageSize = useStore(state => state.setImageSize);
    const setScale = useStore(state => state.setScale);
    const setSize = useStore(state => state.setSize);
    const width = useStore(state => state.width);
    const height = useStore(state => state.height);

    const brightness = 0;

    React.useEffect(() => {
        if (!image) {
            return;
        }
        const scale = Math.min(width / image.width, height / image.height);
        setScale(scale);
        setImageSize({ width: image.width, height: image.height });

        const ratio = image.width / image.height;
        setSize({
            width: width,
            height: width / ratio
        });
    }, [image, width, height, setScale, setImageSize, setSize]);

    const layerRef = React.useRef(null);

    React.useEffect(() => {
        const canvas = layerRef.current.getCanvas()._canvas;
        canvas.style.filter = `brightness(${(brightness + 1) * 100}%)`;
    }, [brightness]);

    return (
        <Layer ref={layerRef}>
            <Image image={image} />
        </Layer>
    );
};
