// /** @type {import('next').NextConfig} */
// const nextConfig = {
//   reactStrictMode: true,
//   swcMinify: true,
// }

// module.exports = nextConfig

module.exports = () => {
  const rewrites = () => {
    return [
      {
        source: "/api",
        destination: "http://localhost:5193/api",
      },
    ];
  };
  return {
    rewrites,
  };
};
