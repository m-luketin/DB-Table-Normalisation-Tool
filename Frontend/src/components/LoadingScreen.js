import React from "react";

const LoadingScreen = () => {
  return (
    <div className="LoadingScreen">
      <section className="wrapper">
        <div className="spinner">
          <i />
          <i />
          <i />
          <i />
        </div>
      </section>
      <p className="description">Please wait while we gather data...</p>
    </div>
  );
};

export default LoadingScreen;
