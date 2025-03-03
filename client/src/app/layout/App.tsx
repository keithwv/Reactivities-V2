import { Box, Container, CssBaseline } from "@mui/material";
import NavBar from "./NavBar";
import ActivityDashboard from "../../features/activities/dashboard/ActivityDashboard";
import { Outlet } from "react-router";


function App() {

  return (
    <Box sx={{ bgcolor: '#eeeeee', minHeight: '100vh' }}>
      <CssBaseline />
      <NavBar />
      <Container maxWidth='xl' sx={{ mt: 3 }}>
        <Outlet />
        <ActivityDashboard />
      </Container>
    </Box>
  )
}

export default App
