import "./globals.css";

export const metadata = {
  title: "Explore Family Trees",
  description: "Generated by create next app",
};

export default function RootLayout({ children }) {
  return (
    <html lang="en">
      <body className='h-screen w-screen'>
        {children}
      </body>
    </html>
  );
}
